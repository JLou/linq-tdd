function keys(object: Object): string[] {
  let toReturn = [];
  for (const key in object) {
    if (Object.prototype.hasOwnProperty.call(object, key)) {
      toReturn.push(key);      
    }
  }
  return toReturn;
}

export { keys };
