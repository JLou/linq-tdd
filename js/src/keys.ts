function keys(object: Object): string[] {
    let toReturn = [];
    for (var i in object) {
        toReturn.push(i);
    }
    return toReturn;
}

export { keys };
