// See https://aka.ms/new-console-template for more information

Console.WriteLine("Linked list implimentation");

//5->4->2->8->null,Search(4)
LinkedList list = new LinkedList(); 
var rand = new Random();
list.InsertAtTail(5); 
list.InsertAtTail(4); 
list.InsertAtTail(2); 
list.InsertAtTail(8); 
 
var result = list.Search(8);

Console.WriteLine("Search result: " + result);
list.PrintList();
