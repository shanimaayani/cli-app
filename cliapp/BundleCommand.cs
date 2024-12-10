using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cliapp
{
    public static class BundleCommand
    {
        public static Command CreateCommand()
        {
            var bundleCommand = new Command("bundle", "Bundle Code files to a single file");

            var languageOption = new Option<string>(
                new[] { "--language", "-l" },
                "Programming language to include (e.g., cs, js, all)");
            languageOption.IsRequired = true;
            bundleCommand.AddOption(languageOption);

            var outputOption = new Option<string?>(
                new[] { "--output", "-o" },
                "Output path for the bundled file (default: 'bundle.txt').");
            bundleCommand.AddOption(outputOption);

            var noteOption = new Option<bool>(
                new[] { "--note", "-n" },
                "Include file names and paths as comments.");
            bundleCommand.AddOption(noteOption);

            var sortOption = new Option<string>(
                new[] { "--sort", "-s" },
                () => "filename",
                "Sorting order (filename or type).");
            bundleCommand.AddOption(sortOption);

            var removeEmptyLinesOption = new Option<bool>(
                new[] { "--remove-empty-lines", "-r" },
                "Remove empty lines from code files.");
            bundleCommand.AddOption(removeEmptyLinesOption);

            var authorOption = new Option<string?>(
                new[] { "--author", "-a" },
                "Include the author's name as a comment at the top.");
            bundleCommand.AddOption(authorOption);

            // Bind the handler
            bundleCommand.SetHandler(
             (string language, string? output, bool note, string sort, bool removeEmptyLines, string? author) =>
             {
                 BundleService.BundleFiles(language, output, note, sort, removeEmptyLines, author);
             },
             languageOption, outputOption, noteOption, sortOption, removeEmptyLinesOption, authorOption);

            return bundleCommand;

        }
    }
}
