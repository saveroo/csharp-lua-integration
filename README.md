# C# Lua Integration Demo

[![Build and Release](https://github.com/saveroo/csharp-lua-integration/actions/workflows/build.yml/badge.svg)](https://github.com/saveroo/csharp-lua-integration/actions/workflows/build.yml)

The CSharp Lua Integration Showcase is a C# WinForms application that demonstrates how to integrate Lua scripts as plugins and execute them within a graphical user interface. It provides a platform for showcasing Lua script capabilities and allows users to interact with and execute Lua scripts that perform various tasks, such as manipulating registry keys, it can be extended to add new controls to the current interface as well.

## Features

- List and select Lua plugins from the "./plugins" folder.
- Validate Lua scripts for structure and required functions.
- Execute selected Lua scripts and display the results.
- Expose custom C# API functions to be called from Lua scripts.
- <del>Provide a default implementation for the custom actions that Lua scripts can override.</del>
- Allow Lua scripts to interact with the Windows Registry.

## Dependencies

- .NET Core 6.0
- NLua library for Lua integration in C# applications.

## Installation

1. Clone the repository or download the source code.
2. Build the solution using Visual Studio or your preferred C# IDE.
3. Run the generated executable to launch the Lua Plugin Showcase application.

## Usage

1. Launch the application.
2. The list of available Lua plugins will be displayed in the list box.
3. Select a Lua plugin from the list.
4. The plugin's name and description will be shown in the respective labels.
5. Click the "Execute" button to run the selected Lua plugin.
6. The result of the plugin execution will be displayed in a message box.

## Example Plugin
```lua
-- Lua script: HelloWorld.lua

-- Plugin information
PluginName = 'HelloWorld Plugin'
PluginAuthor = 'saveroo'
PluginDescription = 'This is a basic Lua plugin that displays a hello lua message.'

-- Entry point function which will be called within C#, for now only supports boolean return value for showcase.
function Main()
    -- Exposed C# API function
    ShowMessageBox('Hello from Lua!', 'C# said')
    -- Expects a boolean return value for flagging success or failure.
    return true
end
```

## Folder Structure

The folder structure of the Lua Plugin Showcase application is as follows:

- `plugins/`: This folder contains the Lua plugins that can be executed by the application. You can add your custom Lua plugins to this folder.

## Customize and Extend

You can customize and extend the Lua Plugin Showcase application in the following ways:

- Add or modify Lua plugins in the `plugins/` folder to showcase different functionalities.
- Implement additional C# API functions and expose them to Lua for more complex interactions.
- Enhance the user interface and functionality of the application as per your requirements.

## License
[![License: CC0-1.0](https://licensebuttons.net/l/zero/1.0/80x15.png)](http://creativecommons.org/publicdomain/zero/1.0/)

This project is dedicated to the public domain under the [Creative Commons Zero (CC0) license](https://creativecommons.org/publicdomain/zero/1.0/).

You can copy, modify, distribute, and use the code or any other elements of this project without asking for permission.
