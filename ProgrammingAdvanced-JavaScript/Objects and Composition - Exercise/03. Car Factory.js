function solve(args) {
    const parts = {
        engine: {
            'Small engine': { power: 90, volume: 1800 },
            'Normal engine': { power: 120, volume: 2400 },
            'Monster engine': { power: 200, volume: 3500 }
        },

        carriage: {
            Hatchback: { type: 'hatchback', color: '' },
            Coupe: { type: 'coupe', color: '' }
        }
    }

    let engine = {};
    if (args.power <= 90) {
        engine = parts.engine["Small engine"];
    } else if (args.power <= 120) {
        engine = parts.engine['Normal engine'];
    } else {
        engine = parts.engine['Monster engine'];
    }

    let carriage = {};
    if (args.carriage == 'hatchback') {
        carriage = parts.carriage['Hatchback'];
    } else {
        carriage = parts.carriage['Coupe'];
    }

    carriage.color = args.color;

    let wheel = 0;

    if (+args.wheelsize % 2 == 0) {
        wheel=args.wheelsize-1;
    }else{
        wheel=args.wheelsize;
    }

    const car = {
        model: args.model,
        engine,
        carriage,
        wheels: [wheel, wheel, wheel, wheel]
    }

    return car;

}