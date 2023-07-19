-- Lua script: idmresetter.lua

-- Plugin information
PluginName = "Registry Key Deletion Plugin"
PluginAuthor = "savero"
PluginDescription = "This plugin deletes a specific registry key."

-- Function to delete a registry key
function Main()
    
    -- Import the required namespaces
    import('System')
    import('Microsoft.Win32')
    
    local keyPath = "S-1-5-21-1240373782-3798373062-2269338184-1001_Classes\\WOW6432Node"
    -- Attempt to delete the registry key
    local subKey = Registry.Users:OpenSubKey(keyPath, true)
    if subKey ~= nil then
        subKey:DeleteSubKeyTree(keyPath)
        return true
    else
        return false
    end
end