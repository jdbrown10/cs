//queues!
//using an array
//first in, first out -> FILL. like a line at the bank. first person in line is the first person served, etc.


class StackNode{
    constructor(value) {
        this.value = value;
        this.next = null;
    }
}

class LinkedListStack{
    constructor(){
        this.head = null;
    }

    //add a value
    push(val){
        var newNode = new StackNode(val);
        if(this.head == null){
            this.head = newNode;
            return this.size();
        }
        var runner = this.head;
        while (runner.next) {
            runner = runner.next;
        }
        runner.next = newNode;
        return this.size();
    }

    //remove and return a value
    pop(){
        if (this.isEmpty()) {
            return null;
        } else if (this.head.next == null){
            var temp = this.head;
            this.head = null;
            return temp.value;
        }
        var runner = this.head;
        while (runner.next) {
            runner = runner.next;
        }
        var temp = runner.next;
        runner.next = null;
        return temp.value;
    }

    //look at top value
    peek(){
        if (this.isEmpty()) {
            return null;
        }
        var runner = this.head
        while (runner.next) {
            runner = runner.next
        }
        return runner.value;
    }

    //is empty?
    isEmpty(){
        return this.head === null;
    }

    //size
    size(){
        var length = 0;
        var runner = this.head;
        while (runner) {
            length++;
            runner = runner.next;
        }
        return length;
    }
}

class ArrayQueue {
    constructor(){
        this.items = [];
    }

    //enqueue
    enqueue(val){
        this.items.push(val);
    }

    //dequeue and return dequeued item
    dequeue(){
        //shift all the indexes over
        if (this.isEmpty()) {
            console.log("This is empty, nothing to dequeue")
        } else {
            var temp = this.items[0]
            for (let i = 0; i < this.items.length; i++) {
                var j = i + 1
                this.items[i] = this.items[j]
            }
            this.items.pop();
            return temp
        }
    }

    //isempty
    isEmpty(){
        return this.items.length === 0;
    }

    //look at front
    checkFront(){
        if (this.isEmpty()) {
            console.log("There's no front, it's empty")
        } else {
            console.log(this.items[0]);
        }
    }
}

//using a singly linked list
class QueueNode{
    constructor(value) {
        this.value = value;
        this.next = null;
    }
}

class LinkedListQueue{
    constructor(){
        this.head = null;
    }

    //enqueue
    enqueue(val){
        if (this.isEmpty()) {
            var newNode = new QueueNode(val);
            this.head = newNode;
        } else {
            var newNode = new QueueNode(val);
            var runner = this.head;
            while (runner.next) {
                runner = runner.next
            }
            runner.next = newNode;
        }
    }
    //dequeue
    dequeue(){
        if (this.isEmpty()) {
            console.log("This queue is empty")
        } else if (this.head.next == null) {
            var temp = this.head.value
            this.head = null;
            return temp;
        } else {
            var temp = this.head.value
            this.head = this.head.next;
            return temp;
        }
    }
    //isempty
    isEmpty(){
        return this.head === null;
    }

    //look at front
    checkFront(){
        if (this.isEmpty()) {
            console.log("It's empty, nothing in front")
        } else {
            console.log(this.head.value)
        }
    }

    //get size
    //ruben told us this was okay lol
    size(){
        var size = 0
        var runner = this.head;
        while (runner) {
            size++;
            runner = runner.next;
        }
        return size
    }

    printValues(){
        if (this.isEmpty()) {
            console.log("it's empty")
        } else {
            var runner = this.head;
            while (runner) {
                console.log(runner.value);
                runner = runner.next;
            }
        }
    }

    //compare 2 queues ONLY using methods you have written and/or a stack
    //return true or false
    //this is destructive
    compareQueues(q2){
        while (!this.isEmpty || !q2.isEmpty()) {
            if (this.dequeue() != q2.dequeue()) {
                return false;
            }
        }
        if (!this.isEmpty() && q2.isEmpty()) {
            return false
        } else if (this.isEmpty() && !q2.isEmpty()) {
            return false
        }
        return true;
    }

    //check if a queue is a palindrome ONLY using built in methods and/or a stack
    //returns true or false
    isPalindrome(){
        // //get the size of the queue
        // var newStack = new LinkedListStack;
        // var halfLength = Math.floor(this.size()/2);

        // //push half into a new stack
        // for (let i = 0; i < halfLength; i++) {
        //     newStack.push(this.dequeue());
        // }
        // if (this.size() != newStack.size()) {
        //     this.dequeue();
        // }
        // console.log("before while loop")
        // //pop from stack and dequeue from queue and check if values are equal
        // while (!this.isEmpty()) {
        //     if (this.dequeue() != newStack.pop()) {
        //         return false
        //     }
        // }
        // return true

    }
}

// var arrQueue = new ArrayQueue;
// console.log(arrQueue.items);
// arrQueue.enqueue(1);
// console.log(arrQueue.items);
// arrQueue.enqueue(5);
// arrQueue.enqueue(8);
// arrQueue.enqueue(11);
// console.log(arrQueue.items);
// console.log(arrQueue.items[1]);
// arrQueue.dequeue();
// console.log(arrQueue.items);
// arrQueue.checkFront();
// arrQueue.dequeue();
// arrQueue.checkFront();

var sllQueue = new LinkedListQueue;
sllQueue.enqueue(2);
sllQueue.enqueue(5);
sllQueue.enqueue(6);
sllQueue.enqueue(1);
var sllQueue2 = new LinkedListQueue;
sllQueue2.enqueue(2);
sllQueue2.enqueue(5);
sllQueue2.enqueue(6);
sllQueue2.enqueue(1);
var sllQueue3 = new LinkedListQueue;
sllQueue3.enqueue(2);
sllQueue3.enqueue(1);
sllQueue3.enqueue(6);
sllQueue3.enqueue(5);
sllQueue3.enqueue(2);
// sllQueue.printValues();
// console.log("=======")
// sllQueue.dequeue();
// sllQueue.printValues();
// console.log("=======")
// sllQueue.dequeue();
// sllQueue.printValues();
// console.log("=======")
// sllQueue.checkFront();
console.log(sllQueue.compareQueues(sllQueue2));
// console.log(sllQueue3.isPalindrome());