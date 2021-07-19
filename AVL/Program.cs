using System;

namespace AVL {
    class Program {
        static void Main(string[] args) {
            var tree = new AVLTree();
            tree.Add(5);
            tree.Add(2);
            tree.Add(3);
            tree.Add(1);
            //tree.Add(4);
            //tree.Add(10);



            tree.Print();
            // Console.WriteLine(tree.Root.Right.Right.Data);
        }
    }
    class Node {
        public Node(int data, Node left = null, Node right = null, int height = 0) {
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

        private Node Add(Node node, int data) {

            if (node == null) return new Node(data);

            if (node.Data > data) node.Left = Add(node.Left, data);

            else node.Right = Add(node.Right, data);

            node.Height = Math.Max(node.Left?.Height ?? 0, node.Right?.Height ?? 0) + 1;


            var dH = node.Left?.Height ?? 0 - node.Right?.Height ?? 0;


            if (dH > 0 && node.Left.Data > data) node = RotateLL(node);

            return node;
        }

        private Node RotateLL(Node node) {
            var new_node = node.Left;
            node.Left = new_node.Right;
            new_node.Right = node;

            node.Height = (node.Left == node.Right && node.Right == null) ? 0 : Math.Max(node.Left?.Height ?? 0, node.Right?.Height ?? 0) + 1;
            new_node.Height = Math.Max(new_node.Left.Height, new_node.Right.Height) + 1;
            return new_node;
        }

        public void Print() => Print(Root);

        private void Print(Node root) {
            if (root == null) return;

            Print(root.Left);
            Console.WriteLine($"{root.Data}:{root.Height}");
            Print(root.Right);
        }
    }
}
