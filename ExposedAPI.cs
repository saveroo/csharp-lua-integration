using NLua;

namespace CSharpLuaIntegration;
/**
     * Exposed API for Lua scripts
     */
class LuaAPI
{
    private readonly Lua lua;

    public LuaAPI(LuaLoader luaLoader)
    {
        lua = luaLoader.LuaInstance;
        RegisterAPI();
    }

    private void RegisterAPI()
    {
        lua.RegisterFunction("ShowMessageBox", null, typeof(LuaAPI).GetMethod("ShowMessageBox"));
        // Add more API methods here if needed
    }

    public static void ShowMessageBox(string message, string caption)
    {
        MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}





