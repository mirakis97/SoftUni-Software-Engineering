function solve(arr) {
    let heroesArr = [];
    for (let i = 0; i < arr.length; i++) {
        let [name, level, items] = arr[i].split(' / ');
        
        level = Number(level);
        items = items !== undefined ? items.split(', ') : [];


        heroesArr.push({name: name, level: level, items: items});
    }

    return JSON.stringify(heroesArr);
}