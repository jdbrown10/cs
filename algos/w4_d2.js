//queues!
//using an array
//first in, first out -> FILL. like a line at the bank. first person in line is the first person served, etc.

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
sllQueue.printValues();
console.log("=======")
sllQueue.dequeue();
sllQueue.printValues();
console.log("=======")
sllQueue.dequeue();
sllQueue.printValues();
console.log("=======")
sllQueue.checkFront();