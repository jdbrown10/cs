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
    min() {
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
    max() {
        var runner = this.root;
        while (runner.right != null) {
            runner = runner.right
        }
        return runner.value
    }

    //how can you tell if a certain value is contained within the tree?
    //passes in a value, and returns true/false
    //you have to use the logic of how a BST is structured
    contains(val) {
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
                runner = runner.right;
            } else {
                runner = runner.left;
            }
        }
        return false
    }

    //do it again recursively
    containsRecursive(val, runner = this.root) {
        if (!runner) {
            return false
        }
        if (runner.value == val) {
            return true
        } else if (runner.value <= val) {
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
    range(BST) {
        if (this.isEmpty()) {
            console.log("There's no range, it's empty lol")
        } else {
            return this.max() - this.min()
        }
    }


    // Given a value, insert it into the correct location in the binary search tree
    insert(val) {
        //make a runner
        //if the root is null, create a root
        if (this.isEmpty()) {
            this.root = new Node(val)
            return this
        } else {
            var runner = this.root;
            var walker = this.root;
            while (runner != null) {
                if (val >= runner.value) {
                    walker = runner;
                    runner = runner.right;
                } else {
                    walker = runner;
                    runner = runner.left;
                }
            }
            if (val >= walker.value) {
                walker.right = new Node(val);
                return this;
            } else {
                walker.left = new Node(val);
                return this;
            }
        }
    }

    // Now that you've solved insert iteratively, write it recursively
    insertRecursive(val, walker = this.root, runner = this.root) {
        if (this.isEmpty()) {
            this.root = new Node(val)
            return this
        }
        if (!runner) {
            if (val >= walker.value) {
                walker.right = new Node(val);
                return this;
            } else {
                walker.left = new Node(val);
                return this;
            }
        } else if (val >= runner.value) {
            return this.insertRecursive(val, runner, runner.right)
        } else {
            return this.insertRecursive(val, runner, runner.left)
        }
    }


    //Preorder -> root, left, right
    //Recursion is going to be really helpful here
    toArrPreorder(node = this.root, vals = []) {
        if (node) {
            vals.push(node.value);
            this.toArrPreorder(node.left, vals);
            this.toArrPreorder(node.right, vals);
        }
        return vals;
    }

    //in order -> left, root, right
    toArrInorder(node = this.root, vals = []) {
        if (node) {
            this.toArrInorder(node.left, vals);
            vals.push(node.value);
            this.toArrInorder(node.right, vals);
        }
        return vals;
    }

    //post order -> left, right, root
    toArrPostorder(node = this.root, vals = []) {
        if (node) {
            this.toArrPostorder(node.left, vals);
            this.toArrPostorder(node.right, vals);
            vals.push(node.value);
        }
        return vals;
    }

    // size -> how many total nodes?
    size(node = this.root) {
        var count = 0
        //use a toArr function as a starting point 
        //but instead of pushing to an array, add to a counter
        //return the counter at the end
        if (node) {
            count++;
            count += this.size(node.left) + this.size(node.right)
        }

        return count

        //OR, could all on toArr and then just get the length of the array lol

        // var array = this.toArrPostorder();
        // return array.length;
    }

    //height -> length of longest branch
    height(node = this.root) {
        if (!node) {
            return 0;
        }
        return 1 + Math.max(this.height(node.left), this.height(node.right));
    }

    //is full? -> all nodes must have either 0 or 2 children
    //think of why it would fail, and test for that
    isFull(root) {
        if (root == null) {
            return true
        }
        if ((root.left == null && root.right == null) || (root.left != null && root.right != null)) {
            return ((this.isFull(root.left)) && (this.isFull(root.right)))
        }
        console.log("not a tree")
        return false
    }
}


//we made a BST and it's empty
var myBST = new BST();
// console.log(myBST.isEmpty());
myBST.insertRecursive(8);
myBST.insertRecursive(2);
myBST.insertRecursive(5);
myBST.insertRecursive(7);
myBST.insertRecursive(999);
myBST.insertRecursive(999);
myBST.insertRecursive(200);
myBST.insertRecursive(22);
myBST.insertRecursive(1002);
console.log(myBST.size());
// console.log(myBST);
// console.log(myBST.root.right);

// console.log(myBST.contains(4));
// console.log(myBST.contains(17));
// console.log(myBST.contains(2));
// console.log(myBST.contains(7));
// console.log(myBST.contains(999));
// console.log(myBST.contains(200));
// console.log(myBST.contains(22));
// console.log(myBST.contains(1002));





// //this is how we artificially add a node-- we'll get into inserting the proper way a bit later
// var nodeA = new Node(6);
// myBST.root = nodeA;
// // console.log(myBST.isEmpty());

// //adding a node to the root-> left because the value is smaller than the root's
// myBST.root.left = new Node(4);
// myBST.root.left.left = new Node(3);
// myBST.root.left.left.left = new Node(2);

// myBST.root.right = new Node(8);
// myBST.root.right.right = new Node(11);
// myBST.root.right.right.right = new Node(41);

// // console.log(myBST.min());

// // console.log(myBST.contains(100));

// // console.log(myBST.containsRecursive(4));
// // console.log(myBST.containsRecursive(100));
// // console.log(myBST.containsRecursive(18));
// // console.log(myBST.containsRecursive(8));
// console.log(myBST.range());