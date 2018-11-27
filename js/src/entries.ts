function entries(object: Object): string[] {
    let toReturn = [];
    for (var i in object) {
        toReturn.push([i, object[i]]);
    }
    return toReturn;
}

export { entries };
