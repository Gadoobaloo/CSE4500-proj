//TODO: Use JSON.parse and JSON.stringify in this code.

console.log('Press the "Start!" button to begin.')

function getInfo(){
  var inputFavColor = window.prompt("What is your favorite color?");
  var inputFavFood = window.prompt("What is your favorite food?");

  const inputObject = {
    favColor: inputFavColor,
    favFood: inputFavFood,
  };

  const myObjStr = JSON.stringify(inputObject);

  console.log(myObjStr);
    
  console.log(JSON.parse(myObjStr));
}