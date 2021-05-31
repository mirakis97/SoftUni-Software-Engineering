function solve(worker) {
    if (worker.dizziness) {
        let reqAmount = worker.experience * worker.weight * 0.1;
        worker.levelOfHydrated += reqAmount;
        worker.dizziness = false
    }
    return worker;
}
console.log(solve({
    weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true
}));