function values(object: Object): any[] {
  let toReturn = [];
  for(let key in object){
    toReturn.push(object[key]);
  }
  return toReturn;
}

export { values };
