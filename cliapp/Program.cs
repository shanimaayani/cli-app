

using cliapp;
using System.CommandLine;
var rootCommand = new RootCommand("CodeBundler CLI")
{
    BundleCommand.CreateCommand(),
    CreateRspCommand.CreateCommand()
};

return await rootCommand.InvokeAsync(args);

