function values(object: Object): string[] {
    let toReturn = [];
    for (var i in object) {
        toReturn.push(object[i]);
    }
    return toReturn;
}

export { values };
