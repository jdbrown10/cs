//doubly linked list!
//it's just a singly linked list but everything also has a .previous
//we're also adding a .tail

class Node {
    constructor(val) {
        this.value = val;
        this.next = null;
        this.previous = null;
    }
}

//for all of the functionality it gives past what a SLL can do, there is also more to keep track of and be careful of it

class DLL {
    constructor() {
        this.head = null;
        this.tail = null;
    }

    isEmpty() {
        return this.head == null;
    }

    toArray() {
        if (this.isEmpty()) {
            console.log("This SLL is empty! There's nothing to print.")
        } else {
            var arr = []
            var runner = this.head;
            while (runner) {
                arr.push(runner.value); //push the data to the array
                runner = runner.next; //move to the next node in the SLL
            }
            console.log(arr);
            return arr;
        }
    }

    //insert at front
    //remember both the head and the tail (if there are no values, it becomes both the head and the tail)
    insertAtFront(val) {
        var newNode = new Node(val);

        //edge case in case the SLL is empty
        if (this.head == null) {
            this.head = newNode;
            this.tail = newNode;
            return this;
        } else {
            newNode.next = this.head;
            this.head.previous = newNode;
            this.head = newNode;
            return this;
        }
    }

    insertAtBack(val) {
        var newNode = new Node(val);

        //edge case in case the SLL is empty
        if (this.head == null) {
            this.head = newNode;
            this.tail = newNode;
            return this;
        } else {
            this.tail.next = newNode;
            newNode.previous = this.tail;
            this.tail = newNode;
            return this;
        }
    }

    //how do you find the middle of a DLL and once you find it, how do you remove it?
    //for an even list, remove the one on the left side (closer to the head)
    removeMiddleNode() {
        //get the length of the DLL
        //change the pointers around to skip over the middle node
        var lengthCounter = 0
        var runner = this.head
        while (runner) {
            lengthCounter++
            runner = runner.next
        }
        //use a runner to go up to the halfway point
        runner = this.head
        for (let i = 0; i < lengthCounter / 2 - 1; i++) {
            runner = runner.next
        }
        runner.previous.next = runner.next
        runner.next.previous = runner.previous
    }

    //insert the first value after we find the second value
    //if val2 isn't in the SLL, don't do anything
    insertAfter(val, val2) {
        //look for val2
        var runner = this.head
        while (runner) {
            if (runner.value == val2) {
                //if runner is also the tail
                if (runner==this.tail) {
                    this.insertAtBack(val)
                } else {
                    //make a new node if we find val2
                    var newNode = new Node(val);
                    //change all the pointers around
                    runner.next.previous = newNode;
                    newNode.next = runner.next
                    runner.next = newNode;
                    newNode.previous = runner;
                }
            }
            runner = runner.next
        }
    }

    //same concept as insertAfter -> look for val2, then run the operation to insert val before if you find it
    insertBefore(val, val2) {
        //look for val2
        var runner = this.head
        while (runner) {

            if (runner.value == val2) {
                //if runner is also the head
                if (runner==this.head) {
                    this.insertAtFront(val)
                    break
                } else {
                    //make a new node if we find val2
                    var newNode = new Node(val);
                    //change all the pointers around
                    runner.previous.next = newNode;
                    newNode.previous = runner.previous;
                    runner.previous = newNode;
                    newNode.next = runner;
                    break
                }
            }
            runner = runner.next
        }
    }
}

var myDLL = new DLL();

myDLL.insertAtFront(4);
myDLL.insertAtFront(5);
myDLL.insertAtFront(7);
myDLL.insertAtFront(11);
myDLL.toArray();
myDLL.insertAtBack(1);
myDLL.insertAtBack(55);
myDLL.insertAtBack(21);
myDLL.toArray();
// myDLL.removeMiddleNode();
// myDLL.toArray();
// myDLL.removeMiddleNode();
// myDLL.toArray();
// myDLL.removeMiddleNode();
// myDLL.toArray();
// myDLL.removeMiddleNode();
// myDLL.toArray();
myDLL.insertBefore(6, 7)
myDLL.insertBefore(1, 11)
myDLL.insertAfter(100, 4)
myDLL.insertAfter(100, 21)
myDLL.toArray();