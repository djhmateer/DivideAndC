class Node:
    def __init__(self,l=None,r=None):
        self.left=l
        self.right=r
    def midway(self):
        return (self.right-self.left)/2 + self.left
   
class Queue (object): 
    def __init__(self, q=None):
        if q is None:
            self.q = []
        else:
            self.q = list(q)
    def pop(self):
        return self.q.pop(0)
    def append(self, element):
        self.q.append(element)
    def length (self):
        return len (self.q)
 
def div_conq (nodelist):
    if (nodelist.length() >0):
        current_node = nodelist.pop()
        midway=current_node.midway()
        print midway
        if (midway < current_node.right-1):
            n=Node(midway,current_node.right)
            nodelist.append(n)
        if (current_node.left < midway-1):
            n=Node(current_node.left,midway)
            nodelist.append(n)
         
        if (nodelist.length() != 0):
            div_conq(nodelist)  
             
        #if (current_node.left<midway):
            #return div_conq(nodelist)
        #if (midway<current_node.right):
            #return div_conq(nodelist)
tar_dist=100
n=Node(1,tar_dist)
print n.left
print n.right
nodelist = Queue()
nodelist.append(n)
div_conq(nodelist)