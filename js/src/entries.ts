function entries(object: Object): [string, any][] {
  let toReturn = [];
  for (const key in object) {
    if (Object.prototype.hasOwnProperty.call(object, key)) {
      const element = object[key];
      toReturn.push([key, element]);
    }
  }
  return toReturn;
}

export { entries };
