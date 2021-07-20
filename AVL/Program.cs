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

    class Node {
        public Node(int data, Node left = null, Node right = null, int height = 1) {
            Data = data;
            Left = left;
            Right = right;
            Height = height;
        }

        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Height { get; set; }
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


            if (dH > 1 && node.Left.Data > data) return RotateLL(node); //5->2->1

            if (dH > 1 && node.Left.Data < data) return RotateLR(node); //5->2->1

            if (dH < -1 && node.Right.Data < data) return RotateRR(node); //15->25->40

            if (dH < -1 && node.Right.Data > data) return RotateRL(node); //15->25->17


            return node;
        }

        private Node RotateLR(Node node) {
            var root = RotateRR(node.Left);
            node.Left = root;
            root = RotateLL(node);
            return root;
        }

        private Node RotateRL(Node node) {
            var root = RotateLL(node.Right);
            node.Right = root;
            root = RotateRR(node);
            return root;
        }

        private Node RotateRR(Node node) {
            var root = node.Right;
            var leftRooot = root.Left;
            node.Right = leftRooot;
            root.Left = node;

            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
            root.Height = Math.Max(Height(root.Left), Height(root.Right)) + 1;

            return root;
        }

        private Node RotateLL(Node node) {
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
