// See https://aka.ms/new-console-template for more information

public class LinkedList
    {
        public LinkedList()
        {
            Head = null;
        }
        public Node? Head {get;set;}

        public bool IsEmpty()
        {
            return this.Head == null;
        }

        public void InsertAtHead(int value)
        {
            var node = new Node();
            node.Data = value;
	        node.NextElement = this.Head;
	        this.Head = node;
        }
        public void InsertAtTail(int value)
        {
            if(IsEmpty())
            {
                InsertAtHead(value);
                return;
            }

            var node = new Node();
            node.Data = value;

            var tailNode = this.Head;
            if(tailNode == null) return;
            while(tailNode.NextElement != null) 
            {
                tailNode = tailNode.NextElement;
            }
        
            tailNode.NextElement = node;
            node.NextElement = null;
        }

        public void InsertAtNth(int value, int n)
        {
            if(n < 1) return;
            if(n == 1 && IsEmpty()) {
                InsertAtHead(value);
                return;
            }

            var node = new Node();
            var i = 1;
            var nthNode = this.Head;

            while (i != n){
                if(nthNode == null) return;
                nthNode = nthNode.NextElement;
                i++;
            }

            if(nthNode == null) return;
            var nthNext = nthNode.NextElement;
            nthNode.NextElement = node;
            node.Data = value;
            node.NextElement = nthNext;
        }

        /// <summary>
        /// function to check if element exists in the list
        /// </summary>
        /// <param name="value">The input is a value to be searched</param>
        /// <returns>true if the value is found but false otherwise.</returns>
        public bool Search(int value)
        {
            if(IsEmpty()) return false;
            
            var currentNode = this.Head;
            while(currentNode != null) 
            {
                if(currentNode.Data == value) return true;
                currentNode = currentNode.NextElement;
            }

            return false;
        }

        public bool DeleteAtHead() {
            if(IsEmpty())return false;
            Head = Head.NextElement;
            return true;
        }

        public bool DeleteAtTail() {
            if(IsEmpty()) return false;
            if(Head.NextElement == null) return DeleteAtHead();
            
            var deleted = false; 
            var currentNode = Head;
            while(currentNode.NextElement != null) {
                if(currentNode.NextElement.NextElement == null){
                    currentNode.NextElement = null;
                    deleted = true;
                    break;
                }
                currentNode = currentNode.NextElement;
            }
            return deleted;
        }

        /// <summary>
        /// Function to delete a node with particular value from the list
        /// </summary>
        /// <param name="value">A value to be deleted</param>
        /// <returns>true if the value is deleted but false otherwise</returns>
        public bool Delete(int value){
            if(IsEmpty()) return false;
            if(Head.Data == value) return DeleteAtHead();

            var deleted = false; 

            var prevNode = Head;
            var currentNode = Head.NextElement;
            while(currentNode != null) {
                if(currentNode.Data == value){
                    prevNode.NextElement = currentNode.NextElement;
                    deleted = true;
                    break;
                }
                prevNode = currentNode;
                currentNode = currentNode.NextElement;
            }
            return deleted;

        }

        public bool PrintList()
        {
            if (IsEmpty())
            {
                Console.Write("List is Empty!");
                return false;
            }
            Node? temp = this.Head;
            Console.Write("List : ");

            while (temp != null)
            {
                Console.Write(temp.Data + "->");
                temp = temp.NextElement;
            }
            Console.WriteLine("null ");
            return true;
        }


        /// <summary>
        /// Given an array of k linked-lists lists, each linked-list is sorted in ascending order.
        /// Function to merge all the linked-lists into one sorted linked-list and return it.
        /// Example:
        /// Input: lists = [[1,4,5],[1,3,4],[2,6]]
        /// Output: [1,1,2,3,4,4,5,6]
        /// </summary>
        /// <param name="lists">array of sorted linked-lists</param>
        /// <returns>merged sorted list</returns>
        public static LinkedList MergeKLists(LinkedList[] lists) {

            var mergedList = new LinkedList();

            for(int i = 0; i < lists.Length; i++) {
                var list = lists[i];
                if(list.Head == null) continue;
                mergedList = MergeLists(mergedList, list);
            }

            return mergedList;
        }

        private static LinkedList MergeLists(LinkedList listA, LinkedList listB)
        {
            if(listB.Head == null) return listA;
            if(listA.Head == null) return listB;

            var mergedList = new LinkedList();

            var listACurrentNode = listA.Head;
            var listBCurrentNode = listB.Head;

            while(listACurrentNode != null && listBCurrentNode != null) {
                if(listACurrentNode.Data <= listBCurrentNode.Data){
                    mergedList.InsertAtTail(listACurrentNode.Data);
                    listACurrentNode = listACurrentNode.NextElement;
                    if(listACurrentNode == null){
                        var listBNextNode = listBCurrentNode;
                        mergedList.InsertAtTail(listBNextNode.Data);
                        while(listBNextNode.NextElement != null){
                            listBNextNode = listBNextNode.NextElement;
                            mergedList.InsertAtTail(listBNextNode.Data);
                        }
                        break;
                    }
                }
                else{
                    mergedList.InsertAtTail(listBCurrentNode.Data);
                    listBCurrentNode = listBCurrentNode.NextElement;
                    if(listBCurrentNode == null){
                        var listANextNode = listACurrentNode;
                        mergedList.InsertAtTail(listANextNode.Data);
                        while(listANextNode.NextElement != null){
                            listANextNode = listANextNode.NextElement;
                            mergedList.InsertAtTail(listANextNode.Data);
                        }
                        break;
                    }
                }

            }

            return mergedList;

        }
}