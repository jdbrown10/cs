//Binary search trees!

//nodes can point into two different directions (not next and previous--that would be a doubly linked list--but to the left and right)

//when you place a value into the tree, you compare it to the value of the root, and ask "is it greater than, or less than the value at my current node?" smaller numbers must go to the left, and larger numbers must go to the right.

//you can have duplicate values-> you just decide for yourself whether to place them to the left or right

//it gets loosely sorted by the root value -> everything left of the root will be less than it, and everything to the right of the root will be greater than it, but otherwise it's not so strict (you can have 10 -> 20 -> 30 to the right and then 30 -> 25 to its left, which would still be to the right of 20...)

//the largest number will always be to the bottom right, and the smallest will always be to the bottom left

//these are a very efficient way to pull data, because you'll always know that the value you're looking for will either be to the left or the right of the root

//Gotta create a node to make this!

class Node {
    constructor(val) {
        this.value = val;
        this.left = null;
        this.right = null;
    }
}

class BST {
    constructor() {
        this.root = null; //this is basically the head, just calling it root to go with the tree analogy
    }

    //all our methods go here

    //this returns true is the root is empty, and returns false if the root is not empty
    isEmpty() {
        return this.root == null;
    }

    //find and return the smallest value of the tree
    //the smallest value is going to be at the furthest left location
    min(){
        //I need to start at the top of the tree
        var runner = this.root;

        //Then I need to go as far left as possible
        //Until the node I am on points to null on the left
        //(it has to be runner.left instead of runner-> if the runner gets to null, then we've gone too far and we won't be able to go backwards to access the smallest value)
        while (runner.left != null) {
            runner = runner.left
        }
        return runner.value
    }

    //how do I find the largest value in my tree?
    //it will be at the furthest right location
    //it's basically the same exact logic as finding the min
    max(){
        var runner = this.root;
        while (runner.right != null){
            runner = runner.right
        }
        return runner.value
    }

    //how can you tell if a certain value is contained within the tree?
    //passes in a value, and returns true/false
    //you have to use the logic of how a BST is structured
    contains(val){
        //code
        //use a runner and create some condition
        //if the runner.value == val then return true
        //if runner.value < val then --> runner.right
        //if runner.value > val then --> runner.left
        //if we get to runner == null then return false
        var runner = this.root;
        while (runner) {
            if (runner.value == val) {
                return true
            } else if (runner.value < val) {
                runner = runner.right
            } else {
                runner = runner.left
            }
        }
        return false
    }

    //do it again recursively
    containsRecursive(val, runner = this.root){
        if (!runner) {
            return false
        }
        if (runner.value == val) {
            return true
        } else if (runner.value <= val){
            return this.containsRecursive(val, runner.right)
        } else if (runner.value > val) {
            return this.containsRecursive(val, runner.left)
        }
    }

    //return the range of values
    //just take the min and subtract it from the max
    //get the max
    //get the min
    //subtract! and return
    range(BST){
        if (this.isEmpty()) {
            console.log("There's no range, it's empty lol")
        } else {
            return this.max() - this.min()
        }
    }
}

//we made a BST and it's empty
var myBST = new BST();
// console.log(myBST.isEmpty());

//this is how we artificially add a node-- we'll get into inserting the proper way a bit later
var nodeA = new Node(6);
myBST.root = nodeA;
// console.log(myBST.isEmpty());

//adding a node to the root-> left because the value is smaller than the root's
myBST.root.left = new Node(4);
myBST.root.left.left = new Node(3);
myBST.root.left.left.left = new Node(2);

myBST.root.right = new Node(8);
myBST.root.right.right = new Node(11);
myBST.root.right.right.right = new Node(41);

// console.log(myBST.min());

// console.log(myBST.contains(100));

// console.log(myBST.containsRecursive(4));
// console.log(myBST.containsRecursive(100));
// console.log(myBST.containsRecursive(18));
// console.log(myBST.containsRecursive(8));
console.log(myBST.range());