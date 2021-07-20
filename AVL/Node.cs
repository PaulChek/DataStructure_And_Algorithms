//Here you can watch it int real life https://visualgo.net/en/bst
namespace AVL {
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
}
