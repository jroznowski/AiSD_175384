using BST;
using System.Runtime.CompilerServices;

Tree bst1 = new Tree();

bst1.AddNode(new NodeT(100));
bst1.Add(bst1.root, new NodeT(200));
bst1.Add(bst1.root, new NodeT(20));
bst1.Add(bst1.root, new NodeT(30));
bst1.Add(bst1.root, new NodeT(10));
bst1.Add(bst1.root, new NodeT(150));
bst1.Add(bst1.root, new NodeT(300));

bst1.inOrder(bst1.root);
Console.WriteLine("---------------");
bst1.preOrder(bst1.root);
bst1.Remove(30);
Console.WriteLine("---------------");
bst1.inOrder(bst1.root);
Console.WriteLine("---------------");
bst1.preOrder(bst1.root);