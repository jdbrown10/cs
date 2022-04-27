//singly linked lists!

//gotta make a node class first

class Node {
    constructor(val) {
        this.value = val;
        this.next = null;
    }
}

// Single Linked List class


class SLL {
    constructor() {
        this.head = null;
    }

    //this is where all of our methods are going to live
    //how do we know if the list is empty or not?

    //this is a condition (==) that will return a boolean value. if it's true, it will return true. if it's false, it will return false.
    isEmpty() {
        return this.head == null;
    }

    //send all values to an array and print those values out
    toArray() {
        if (this.isEmpty()) {
            console.log("This SLL is empty! There's nothing to print.")
        } else {
            var arr = []
            var runner = this.head;
            while (runner) {
                arr.push(runner.value); //push the value to the array
                runner = runner.next; //move to the next node in the SLL

            }
            console.log(arr);
        }
    }


    //Add a node to the list
    //The first value must be the head
    insertAtBack(val) {
        //step one: check if the list is empty
        if (this.isEmpty()) {
            //this automatically triggers if there is nothing at the head
            this.head = new Node(val)
        } else {
            //there is something already and we need to add to the back of the list
            //I need to go through my list until the .next points to null
            var runner = this.head
            //since we don't know how many times we'll do this, we need a while loop
            while (runner.next != null) {
                //while there is still a node to move down to...
                runner = runner.next //this will move the runner one node down the list
            }
            runner.next = new Node(val)
        }

    }
    //add a new node to the front of the list
    insertAtFront(val) {
        //edge case in case the SLL is empty
        var newNode = new Node(val)

        if (this.head == null) {
            this.head = newNode
            return this
        } else {
            newNode.next = this.head
            this.head = newNode
            return this
        }
    }



    //remove the node from the front of the list and return the value that was removed
    removeFromFront() {
        console.log("Removing from front!")
        if (this.head == null) {
            console.log("This SLL is empty, there's nothing to remove.")
        } else {
            var val = this.head.value
            this.head = this.head.next
            console.log(val)
            return val
        }
    }



    //calculate the average of all of the values inside of the SLL
    //prob use a counter to increment as we add them, and then divide the total by the counter
    getAverage() {
        if (this.head == null) {
            console.log("This SLL is empty, there's nothing to remove.")
        } else {
            var sum = 0
            var counter = 0
            var runner = this.head
            while (runner != null) {
                sum += runner.value
                // console.log("Counter before incrementing:" + counter)
                counter++
                // console.log("Counter after incrementing:" + counter)
                runner = runner.next
            }
            return sum / counter
        }
    }

    //check if a certain value is inside the SLL 
    //iterative way
    checkValueIterative(val) {
        if (this.head == null) {
            console.log("This SLL is empty, there's nothing to remove.")
        } else {
            var runner = this.head
            while (runner != null) {
                if (runner.value == val) {
                    return true
                }
                else {
                    runner = runner.next
                }
            }
            return false
        }
    }

    //recursive way
    checkValueRecursive(val, runner = this.head) {
        if (runner == null) {
            return false
        }
        //the value is in there
        if (runner.value == val) {
            return true
        } 
        //do the function again
        else if (runner.value != val) {
            runner = runner.next
            return this.checkValueRecursive(val, runner)
        } 
    }

    removeFromBack() {
        if (this.head == null) {
            console.log("This SLL is empty, there's nothing to remove.")
        } else if (this.head.next == null) {
            var temp = this.head.value
            this.head = null
            return temp
        } else {
            var runner = this.head
            while (runner.next.next != null) {
                runner = runner.next
            }
            var temp = runner.next.value
            runner.next = null
            return temp
        }
    }
}

var mySLL = new SLL();
// console.log(mySLL.isEmpty());
mySLL.insertAtBack(3);
mySLL.insertAtBack(5);
mySLL.insertAtBack(8);
mySLL.insertAtFront(5);
mySLL.insertAtFront(11);
// mySLL.toArray();
// mySLL.removeFromFront();
mySLL.toArray();
// console.log(mySLL.getAverage());
console.log(mySLL.checkValueIterative(200));
// mySLL.removeFromBack();
console.log(mySLL.checkValueRecursive(5));
mySLL.toArray();
// mySLL.removeFromBack();
// mySLL.toArray();
// mySLL.removeFromBack();
// mySLL.toArray();
// console.log(mySLL.removeFromBack());
