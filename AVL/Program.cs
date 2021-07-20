//Here you can watch it int real life https://visualgo.net/en/bst
using System;
namespace AVL {
    class Program {
        static void Main(string[] args) {
            var tree = new AVLTree();

            tree.Add(15);
            tree.Add(10);
            tree.Add(11);
            tree.Add(23);
            tree.Add(56);
            tree.Add(33);
            tree.Add(30);
           


            tree.PrePrint();
        }
    }


    class AVLTree {

        public Node Root { get; set; } = null;

        public void Add(int data) => Root = Add(Root, data);
        private int Height(Node node) => node == null ? 0 : node.Height;

        private Node Add(Node node, int data) {

            if (node == null) return new Node(data);

            if (node.Data > data) node.Left = Add(node.Left, data);

            else node.Right = Add(node.Right, data);


            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;

            var dH = Height(node.Left) - Height(node.Right);


            if (dH > 1 && node.Left.Data > data) return CaseLL(node); //5->2->1

            if (dH > 1 && node.Left.Data < data) return CaseLR(node); //5->2->1

            if (dH < -1 && node.Right.Data < data) return CaseRR(node); //15->25->40

            if (dH < -1 && node.Right.Data > data) return CaseRL(node); //15->25->17


            return node;
        }

        private Node CaseLR(Node node) {
            var root = CaseRR(node.Left);
            node.Left = root;
            root = CaseLL(node);
            return root;
        }

        private Node CaseRL(Node node) {
            var root = CaseLL(node.Right);
            node.Right = root;
            root = CaseRR(node);
            return root;
        }

        private Node CaseRR(Node node) {
            var root = node.Right;
            var leftRooot = root.Left;
            node.Right = leftRooot;
            root.Left = node;

            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
            root.Height = Math.Max(Height(root.Left), Height(root.Right)) + 1;

            return root;
        }

        private Node CaseLL(Node node) {
            var root = node.Left;
            node.Left = root.Right;
            root.Right = node;

            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
            root.Height = Math.Max(Height(root.Left), Height(root.Right)) + 1;
            return root;
        }

        public void Print() => Print(Root);

        public void PrePrint() => PrePrint(Root);

        private void PrePrint(Node node) {
            if (node == null) return;
            Console.WriteLine(node.Data + ":" + node.Height);
            PrePrint(node.Left);
            PrePrint(node.Right);
        }

        private void Print(Node root) {
            if (root == null) return;

            Print(root.Left);
            Console.WriteLine($"{root.Data}:{root.Height}");
            Print(root.Right);
        }
    }
}
