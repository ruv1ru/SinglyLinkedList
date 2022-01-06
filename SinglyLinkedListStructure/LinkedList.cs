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
            
            var cureentNode = this.Head;
            while(cureentNode != null) 
            {
                if(cureentNode.Data == value) return true;
                cureentNode = cureentNode.NextElement;
            }

            return false;
        }

        public bool DeleteAtHead(){
            if(IsEmpty())return false;
            Head = Head.NextElement;
            return true;
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
    }