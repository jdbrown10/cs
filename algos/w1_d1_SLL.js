//singly linked lists!

//gotta make a node class first

class Node {
    constructor(val){
        this.data = val;
        this.next = null;
    }
}

// Single Linked List class


class SLL {
    constructor(){
        this.head = null;
    }

    //this is where all of our methods are going to live
    //how do we know if the list is empty or not?

    //this is a condition (==) that will return a boolean value. if it's true, it will return true. if it's false, it will return false.
    isEmpty(){
        return this.head == null;
    }

    //send all values to an array and print those values out
    toArray(){
        if (this.isEmpty()) {
            console.log("This SLL is empty! There's nothing to print.")
        } else{
            var arr = []
            var runner = this.head;
            while(runner){
                arr.push(runner.data); //push the data to the array
                runner = runner.next; //move to the next node in the SLL
            }
            console.log(arr);
        }
    }


    //Add a node to the list
    //The first value must be the head
    insertAtBack(val){
        //step one: check if the list is empty
        if(this.isEmpty()){
            //this automatically triggers if there is nothing at the head
            this.head = new Node(val)
        } else{
            //there is something already and we need to add to the back of the list
            //I need to go through my list until the .next points to null
            var runner = this.head
            //since we don't know how many times we'll do this, we need a while loop
            while (runner.next != null){
                //while there is still a node to move down to...
                runner = runner.next //this will move the runner one node down the list
            }
            runner.next = new Node(val)
        }
    }
}



var mySLL = new SLL();
console.log(mySLL.isEmpty());
mySLL.insertAtBack(3);
mySLL.insertAtBack(5);
mySLL.insertAtBack(8);
console.log(mySLL);