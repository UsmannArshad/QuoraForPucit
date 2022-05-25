var collection = document.getElementsByClassName("like-btn");
var collection1 = document.getElementsByClassName("dislike-btn");
for (let i = 0; i < collection.length; i++) {
  collection[i].onclick=function(){
    if(collection[i].style.backgroundColor!="blue")
    {
    collection[i].style.backgroundColor="blue"
    collection1[i].disabled=true
    }
    else
    {
      collection[i].style.backgroundColor="white"
      collection1[i].disabled=false
    }  
  }
}
for (let i = 0; i < collection1.length; i++) {
  collection1[i].onclick=function(){
    if(collection1[i].style.backgroundColor!="red")
    {
    collection1[i].style.backgroundColor="red"
    collection[i].disabled=true
    }
    else
    {
      collection1[i].style.backgroundColor="white"
      collection[i].disabled=false
    }  
  }
}