// See https://aka.ms/new-console-template for more information

Console.WriteLine("Linked list implimentation");

//5->4->2->8->null,Search(4)
/*LinkedList list = new LinkedList(); 
var rand = new Random();
list.InsertAtTail(5); 
list.InsertAtTail(4); 
list.InsertAtTail(2); 
list.InsertAtTail(8); 
 
var result = list.Search(8);

Console.WriteLine("Search result: " + result);
list.PrintList();
*/


//Input: lists = [[1,4,5],[1,3,4],[2,6]]
//Output: [1,1,2,3,4,4,5,6]

var lists = new LinkedList[3];

lists[0] = new LinkedList();
lists[0].InsertAtTail(1); 
lists[0].InsertAtTail(4); 
lists[0].InsertAtTail(5); 

lists[1] = new LinkedList();
lists[1].InsertAtTail(1); 
lists[1].InsertAtTail(3); 
lists[1].InsertAtTail(4); 

lists[2] = new LinkedList();
lists[2].InsertAtTail(2); 
lists[2].InsertAtTail(6); 

lists[0].PrintList();
lists[1].PrintList();
lists[2].PrintList();

var sortedList = LinkedList.MergeKLists(lists);


sortedList.PrintList();


Console.WriteLine("Linked list implimentationsss");
