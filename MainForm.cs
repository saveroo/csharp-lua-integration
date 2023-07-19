using NLua;

namespace CSharpLuaIntegration
{
    public partial class MainForm : Form, IDisposable
    {
        private readonly string pluginsFolderPath = "./plugins";
        private Lua lua;
        private readonly LuaLoader luaLoader;
        private readonly LuaAPI luaAPI;

        public MainForm()
        {
            InitializeComponent();
            luaLoader = new LuaLoader();
            luaAPI = new LuaAPI(luaLoader);
            Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CreatePluginsFolder();
            InitializePluginsFolder();
            LoadPlugins();

            pluginListBox.SelectedIndexChanged += PluginListBox_SelectedIndexChanged;
            executeBtn.Click += ExecuteBtn_Click;
        }

        private void LoadPlugins()
        {
            pluginListBox.Items.Clear();
            string[] luaScriptFiles = Directory.GetFiles(pluginsFolderPath, "*.lua");
            pluginListBox.Items.AddRange(luaScriptFiles.Select(Path.GetFileNameWithoutExtension).ToArray());
        }

        private void CreatePluginsFolder()
        {
            if (!Directory.Exists(pluginsFolderPath))
            {
                Directory.CreateDirectory(pluginsFolderPath);
            }
        }

        private void InitializePluginsFolder()
        {
            string helloWorldLuaScriptPath = Path.Combine(pluginsFolderPath, "HelloWorld.lua");

            if (!File.Exists(helloWorldLuaScriptPath))
            {
                string luaScriptContent = @"-- Lua script: HelloWorld.lua

-- Plugin information
PluginName = 'HelloWorld Plugin'
PluginAuthor = 'saveroo'
PluginDescription = 'This is a basic Lua plugin that displays a hello lua message.'

-- Entry point function which will be called within C#, for now only supports boolean return value for showcase.
function Main()
    LuaAPI.ShowMessageBox('Hello from Lua!', 'Lua Message')
    return true
end";

                File.WriteAllText(helloWorldLuaScriptPath, luaScriptContent);
            }
        }

        private void PluginListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedLuaScript = pluginListBox.SelectedItem as string;

            if (selectedLuaScript == null)
            {
                MessageBox.Show("Please select a Lua script.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string luaScriptPath = Path.Combine(pluginsFolderPath, selectedLuaScript + ".lua");

            if (!File.Exists(luaScriptPath))
            {
                MessageBox.Show("File Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            // Retrieve plugin information from Lua
            luaLoader.LoadLuaScript(luaScriptPath);
            string? pluginName = luaLoader.GetPluginName();
            string? pluginDescription = luaLoader.GetPluginDescription();

            labelPluginName.Text = $@"Plugin: {pluginName}";
            tboxPluginDescription.Text = pluginDescription;
        }
        

        private void ExecuteBtn_Click(object sender, EventArgs e)
        {
            string selectedLuaScript = pluginListBox.SelectedItem as string;

            if (selectedLuaScript == null)
            {
                MessageBox.Show("Please select a Lua script.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string luaScriptPath = Path.Combine(pluginsFolderPath, selectedLuaScript + ".lua");
            MessageBox.Show("Executing Lua script: " + luaScriptPath);
            luaLoader.ExecuteLuaScript(luaScriptPath);
        }

        public void Dispose()
        {
            lua?.Dispose();
            luaLoader?.Dispose();
        }
    }
}