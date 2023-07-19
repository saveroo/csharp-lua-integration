using NLua;

namespace CSharpLuaIntegration;

/**
     * LuaLoader class for managing Lua instances
     */
class LuaLoader : IDisposable
{
    private readonly Lua lua;
    public Lua LuaInstance => lua;

    public LuaLoader()
    {
        lua = new Lua();
        lua.LoadCLRPackage();
    }

    public void LoadLuaScript(string luaScriptPath) {
        if (!File.Exists(luaScriptPath))
        {
            MessageBox.Show("Lua script file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        lua.DoFile(luaScriptPath);
    }

    public void ExecuteLuaScript(string luaScriptPath)
    {
        try
        { 
            lua.LoadCLRPackage();
            LoadLuaScript(luaScriptPath);

            if (!ValidateLuaScriptStructure(luaScriptPath))
            {
                MessageBox.Show("Invalid Lua script structure.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            LuaFunction mainFunction = lua.GetFunction("Main");
            object[] result = mainFunction.Call();
            bool success = Convert.ToBoolean(result[0]);

            MessageBox.Show(success ? "Plugins executed." : "Plugins failed to execute.",
                "Execution Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error executing Lua script: {ex.Message}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
    
    private bool ValidateLuaScriptStructure(string luaScriptPath)
    {
        if (!File.Exists(luaScriptPath))
        {
            return false;
        }

        lua.DoFile(luaScriptPath);
        return lua.GetFunction("Main") != null;
    }

    public string? GetPluginName()
    {
        return lua["PluginName"] as string;
    }

    public string? GetPluginDescription()
    {
        return lua["PluginDescription"] as string;
    }

    public void Dispose()
    {
        lua?.Dispose();
    }
}
