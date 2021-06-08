function solve(input) {

    let processor = executeCommand();

    for (const item of input) {


        let data = item.split(' ');
        let name = data[1];

        if (data[0] === 'create') {

            processor.create(name);

            if (data[2] === 'inherit') {

                let parentName = data[3];

                processor.inherit(name, parentName)
            }


        } else if (data[0] === 'set') {

            let key = data[2];
            let value = data[3];

            processor.set(name, key, value)



        } else if (data[0] === 'print') {

            processor.print(name);
        }




    }


    function executeCommand() {

        let result = {};

        return {
            create,
            inherit,
            set,
            print,
        };

        function create(name) {
            result[name] = {};
        }

        function inherit(name, parentName) {

            result[name] = Object.create(result[parentName]);

        }

        function set(name, key, value) {

            result[name][key] = value;
        }

        function print(name) {

            let logs = [];

            for (const key in result[name]) {

                logs.push(`${key}:${result[name][key]}`)
            }

            console.log(logs.join(', '));


        }



    }


}