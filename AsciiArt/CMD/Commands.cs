using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArt.CMD
{
    public static class Commands
    {
        private static Node Master = new("asciiart");

        private class Node
        {
            public string Name { get; set; }
            public Delegate Action { get; set; }
            public Node Parent { get; set; }
            public List<Node> Children { get; set; } = new List<Node>();

            public Node(string n, Node parent = null, Delegate action = null)
            {
                Name = n;
                Parent = parent;
                Action = action;
            }

        }

        public static void AddCommand(List<string> args, Delegate act)
        {
            Node nodePtr = Master;
            for (int i = 0; i < args.Count - 1; i++)
            {
                string arg = args[i].Trim();
                var child = nodePtr.Children.Where(n => n.Name.Equals(arg, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                var x = child.Name;
                if (child == null)
                {
                    Node newNode = new(arg, nodePtr);
                    nodePtr.Children.Add(newNode);
                    nodePtr = newNode;
                    continue;
                }

                nodePtr = child;


            }
            nodePtr.Children.Add(new(args.Last(), nodePtr, action: act));
        }

        public static void Execute(string[] args)
        {
            Node nodePtr = Master;
            int i;
            for (i = 0; i < args.Length; i++)
            {
                string arg = args[i];
                try
                {
                    nodePtr = nodePtr.Children.Where(n => n.Name.Equals(arg, StringComparison.OrdinalIgnoreCase)).First();
                    var IsTheLeaf = !(nodePtr.Children.Where(n => n.Name.Equals(args[i+1], StringComparison.OrdinalIgnoreCase)).Any());
                    if (IsTheLeaf) break;
                }
                catch
                {
                    Console.WriteLine($"there is no such option {arg} that exists in this context");
                    return;
                }
            }

            List<object> param = new List<object>();
            var requestedParameters = nodePtr.Action!.Method.GetParameters();

            int j = 0;
            for (i = ++i; i < args.Length; i++)
            {
                var p = Convert.ChangeType(args[i], requestedParameters[j].ParameterType);
                param.Add(p);
                j++;
            }

            var paramsCount = requestedParameters.Length;
            var existingParams = param.Count;
            var missing = paramsCount - existingParams;

            for (int p = 0; p < missing; p++)
            {
                param.Add(Type.Missing);
            }

            try
            {
                nodePtr.Action.Method.Invoke(null, param.ToArray());
            }
            catch (ArgumentException)
            {
                Console.WriteLine("missing/too much parameters");
            }
        }

        public static void Init()
        {
            
            AddCommand(new() { "-i" }, Functions.Image.Facade.DrawImage);
            AddCommand(new() { "-v" }, Functions.Video.Facade.DrawVideo);
            AddCommand(new() { "-l" }, Functions.Live.Facade.LiveCapture);
            AddCommand(new() { "--live" }, Functions.Live.Facade.LiveCapture);
            AddCommand(new() { "-t" }, Functions.Text.Facade.DrawText);
            AddCommand(new() { "-t", "-r" }, Functions.Text.Facade.DrawTextRandomFont);
            AddCommand(new() { "-t ", "-d" }, Functions.Text.Facade.DrawTextWithDefaultDecoration);
            AddCommand(new() { "-t ", "--decorate" }, Functions.Text.Facade.DrawTextWithCustomDecoration);
            AddCommand(new() { "--fonts" }, Functions.Text.Facade.GetFontNames);
        }
    }
}
