//stacks!
//using an array
//first in, last out -> FILL. like a can of pringles. you add and also take things out from the back.

class ArrayStack {
    constructor(){
        this.items = [];
    }

    //add a value
    push(val){
        this.items.push(val);
        return this.size();
    }

    //remove a value (always the last one)
    pop(){
        return this.items.pop();
    }

    //look at top value
    peek(){
        return this.items[this.items.length - 1];
    }

    //is empty?
    isEmpty(){
        return this.items.length === 0;
    }

    //size
    size(){
        return this.items.length;
    }
}

//stack with a singly linked list

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
        var newNode = StackNode(val);
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

var arrStack = new ArrayStack;
console.log(arrStack);
arrStack.push(1);
console.log(arrStack);