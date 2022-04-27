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
            console.log("This SLL is empty! There's nothing to print.");
        } else {
            var arr = [];
            var runner = this.head;
            while (runner) {
                arr.push(runner.value); //push the value to the array
                runner = runner.next; //move to the next node in the SLL
            }
            console.log(arr);
            return arr;
        }
    }

    //Add a node to the list
    //The first value must be the head
    insertAtBack(val) {
        //step one: check if the list is empty
        if (this.isEmpty()) {
            //this automatically triggers if there is nothing at the head
            this.head = new Node(val);
        } else {
            //there is something already and we need to add to the back of the list
            //I need to go through my list until the .next points to null
            var runner = this.head;
            //since we don't know how many times we'll do this, we need a while loop
            while (runner.next != null) {
                //while there is still a node to move down to...
                runner = runner.next; //this will move the runner one node down the list
            }
            runner.next = new Node(val);
        }
    }
    //add a new node to the front of the list
    insertAtFront(val) {
        //edge case in case the SLL is empty
        var newNode = new Node(val);

        if (this.head == null) {
            this.head = newNode;
            return this;
        } else {
            newNode.next = this.head;
            this.head = newNode;
            return this;
        }
    }

    //remove the node from the front of the list and return the value that was removed
    removeFromFront() {
        console.log("Removing from front!");
        if (this.head == null) {
            console.log("This SLL is empty, there's nothing to remove.");
        } else {
            var val = this.head.value;
            this.head = this.head.next;
            console.log(val);
            return val;
        }
    }

    //calculate the average of all of the values inside of the SLL
    //prob use a counter to increment as we add them, and then divide the total by the counter
    getAverage() {
        if (this.head == null) {
            console.log("This SLL is empty, there's nothing to remove.");
        } else {
            var sum = 0;
            var counter = 0;
            var runner = this.head;
            while (runner != null) {
                sum += runner.value;
                // console.log("Counter before incrementing:" + counter)
                counter++;
                // console.log("Counter after incrementing:" + counter)
                runner = runner.next;
            }
            return sum / counter;
        }
    }

    //check if a certain value is inside the SLL
    //iterative way
    checkValueIterative(val) {
        if (this.head == null) {
            console.log("This SLL is empty, there's nothing to remove.");
        } else {
            var runner = this.head;
            while (runner != null) {
                if (runner.value == val) {
                    return true;
                } else {
                    runner = runner.next;
                }
            }
            return false;
        }
    }

    //recursive way
    checkValueRecursive(val, runner = this.head) {
        if (runner == null) {
            return false;
        }
        //the value is in there
        if (runner.value == val) {
            return true;
        }
        //do the function again
        else if (runner.value != val) {
            runner = runner.next;
            return this.checkValueRecursive(val, runner);
        }
    }

    removeFromBack() {
        if (this.head == null) {
            console.log("This SLL is empty, there's nothing to remove.");
        } else if (this.head.next == null) {
            var temp = this.head.value;
            this.head = null;
            return temp;
        } else {
            var runner = this.head;
            while (runner.next.next != null) {
                runner = runner.next;
            }
            var temp = runner.next.value;
            runner.next = null;
            return temp;
        }
    }

    //return the second to last value in the SLL (but don't remove it)
    penultimate() {
        if (this.head == null) {
            console.log("This SLL is empty! There's no penultimate value.");
        } else if (this.head.next == null) {
            console.log("This SLL only has one value!");
        } else {
            runner = this.head;
            while (runner.next.next != null) {
                runner = runner.next;
            }
            return runner.value;
        }
    }

    //given a value, find it and remove it from the SLL, and then return a boolean
    //find the node before it, and point it at the node after it
    //if there's more than one, just remove the first one.
    removeOne(val) {
        if (!this.checkValueIterative(val)) {
            return false;
        } else if (this.head.next == null) {
            this.head = null;
            return true;
        } else if (this.head.data == val) {
            this.removeFromFront();
            return true;
        } else {
            var runner = this.head;
            while (runner.next.value != val) {
                runner = runner.next;
            }
            runner.next = runner.next.next;
            return true;
        }
    }

    //if there's more than one, remove all of them!
    removeAll(val) {
        if (!this.checkValueIterative(val)) {
            return false;
        } else if (this.head.data == val) {
            this.removeFromFront();
            this.removeAll(val);
            return true;
        } else {
            var runner = this.head;
            while (runner.next.value != val) {
                runner = runner.next;
            }
            runner.next = runner.next.next;
            this.removeAll(val);
            return true;
        }
    }

    //concatinate two singly linked lists-> given one SLL, add a second one to it by linking the last node of the first to the head of the second list
    //use a runner to get to the last node of the first SLL
    //point its .next at the head of the second SLL
    //gonna have to get rid of the head of the second SLL so the new SLL doesn't have two heads
    //return the new SLL
    concatSLL(sll2) {
        if (this.head == null) {
            console.log("This SLL is empty! There's no penultimate value.");
        } else {
            var runner = this.head;
            while (runner.next != null) {
                runner = runner.next;
            }
            runner.next = sll2.head;
            // sll2.head = this.head --- is this necessary?
            return this;
        }
    }

    //look for the smallest number in the SLL and move it to the front
    //first find the minimum
    //move the min pointer to the head, and then set the head to be the min
    //change the pointers around so that the node before the min is pointing to the node after the min
    moveMinToFront() {
        //check if SLL is empty
        if (this.head == null) {
            console.log("This SLL is empty! There's no minimum value.");
        } else {
            var runner = this.head
            var beforeMin = this.head
            var min = runner
            //move the runner through the SLL
            while (runner.next != null) {
                //if the min value is greater than the next runner value, set the beforeMin node to become the runner, and the min node to become the runner.next node
                if (min.value > runner.next.value) {
                    beforeMin = runner
                    min = runner.next
                }
                runner = runner.next
            }
            //if the min is still at the head (we never found a smaller value), then just end the function
            if (min == this.head) {
                return this
                //otherwise, use the beforeMin.next to skip over the min node
                //then set min to point at the current head
                //and then change the head pointer to point at the min node
            } else {
                beforeMin.next = beforeMin.next.next
                min.next = this.head
                this.head = min
            }
        }
    }

    //given a value, look through the SLL for it. and if you find it, split the SLL into two SLLs in front of that node, and return the two lists
    //(you'll need to create a new SLL)
    splitOnVal(val) {
        if (!this.checkValueIterative(val)) {
            console.log("That value isn't inside the SLL.")
            return this;
        }
        var runner = this.head;
        while (runner.next.value != val) {
            runner = runner.next
        }
        //the runner should now be at the node before the node containing the value
        //create a new SLL
        var newSLL = new SLL()
        //set the head of the new SLL to be runner.next
        newSLL.head = runner.next
        //point the runner.next to null
        runner.next = null
        return newSLL
    }

    //take the SLL and reverse it
    //destructively or non-destructively is fine -> maybe try both
    reverse(){
        var arr = this.toArray()
        var arrLength = arr.length
        this.head = null
        //loop through the array backwards
        for (let i = 0; i < arrLength; i++) {
            //pop from the array into the new SLL
            this.insertAtBack(arr.pop())
        }
        return this
    }

    //check if list has an infinite loop -> how would you identify that a loop is happening?
    //should return true or false
    //you can fabricate a loop to test this function out on
    checkForLoop(){
        //two runners
        //one runner incremented one node at a time
        //the other incremented two nodes at a time
        //if they ever ended up at the same node, then we had to be in a loop -> return true
        //if one ever reached null, then it isn't a loop -> return false
        if (this.isEmpty()) {
            console.log("This SLL is empty")
            return false
        }
        var walker = this.head
        var runner = this.head.next

        //if either walker or runner ever ends up null, we can just break out of this while loop and return false-> there's no infinite loop
        while (walker && runner) {
            //increment walker to the next node
            walker = walker.next

            //we need to increment the runner twice (so it's moving at a different speed from the walker), but if runner.next ends up being null, then we can't say runner.next.next -> so we have to check if runner.next exists first
            if (runner.next) {
                //now we can increment it to move two nodes ahead
                runner = runner.next.next
            } else {
                //since runner.next doesn't exist, we know it isn't an infinite loop anyway, so just go ahead and return false
                return false
            }
            //they're moving at different speeds, so if they ever end up at the same exact node, we know that they've overlapped each other and we are in an infinite loop
            if (walker == runner) {
                return true
            }
        }
        return false
    }

    //beware lol
    createLoop(){
        //find the last node in the SLL
        //point it at the head
        var runner = this.head
        while (runner.next) {
            runner = runner.next
        }
        runner.next = this.head
    }

    //remove all negative values
    removeNegatives(){
        //check if list is empty
        if (this.isEmpty()) {
            console.log("This SLL is empty")
            return this
        }
        //use a runner to go through the SLL
        var runner = this.head
        
        //use the runner to check if the node's value is negative
        while (runner) {
            var temp = runner.next
            //if it is negative, use RemoveOne to remove it
            if (runner.value < 0) {
                this.removeOne(runner.value)
            }
            runner = temp
        }
        return this
    }
}

var mySLL = new SLL();
var mySLL2 = new SLL();
// console.log(mySLL.isEmpty());
mySLL.insertAtBack(-3);
mySLL.insertAtBack(5);
mySLL.insertAtBack(-8);
mySLL.insertAtBack(-14);
mySLL.insertAtFront(5);
mySLL.insertAtFront(11);
// mySLL2.insertAtBack(3);
// mySLL2.insertAtBack(5);
// mySLL2.insertAtBack(13);
// mySLL2.insertAtBack(8);
// mySLL2.insertAtFront(5);
// mySLL2.insertAtFront(11);
mySLL.toArray();
// mySLL.removeFromFront();
// mySLL.toArray();
// mySLL2.toArray();
// console.log("=========");
// console.log(mySLL.getAverage());
// mySLL.concatSLL(mySLL2);
// mySLL.toArray();
// mySLL.insertAtFront(20);
// mySLL.toArray();
// mySLL.moveMinToFront();
// mySLL.toArray();
// mySLL.moveMinToFront();
// mySLL.toArray();
// console.log(mySLL.splitOnVal(3));
// mySLL.reverse();
// mySLL.toArray();
// mySLL.createLoop();
// console.log(mySLL.checkForLoop());
mySLL.removeNegatives();
mySLL.toArray();