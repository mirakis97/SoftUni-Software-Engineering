function createAssemblyLine() {
    const newAssembly = {
        hasClima: function (obj) {
            obj['temp'] = 21;
            obj['tempSettings'] = 21;

            obj['adjustTemp'] = function () {
                if (obj.temp < obj.tempSettings) {
                    obj.temp++;
                }
                else if (obj.temp > obj.tempSettings) {
                    obj.temp--
                }
            };
        },
        hasAudio: function (obj) {
            obj['currentTrack'] = {name: null, artist: null};

            obj['nowPlaying'] = function () {
                if (obj.currentTrack !== null) {
                    console.log(`Now playing '${obj.currentTrack.name}' by ${obj.currentTrack.artist}`);
                }
            }
        },
        hasParktronic: function (obj) {
            obj['checkDistance'] = function (distance) {
                let msg = 'Beep!';

                if (distance < 0.1) {
                    msg = (msg + ' ').repeat(3).trim();
                }
                else if (0.1 <= distance && distance < 0.25) {
                    msg = (msg + ' ').repeat(2).trim();
                }
                else if (distance >= 0.5) {
                    msg = '';
                }
                console.log(msg);
            }
        }
    }
    return newAssembly;
}
const assemblyLine = createAssemblyLine();

const myCar = {
    make: 'Toyota',
    model: 'Avensis'
};

assemblyLine.hasClima(myCar);
console.log(myCar.temp);
myCar.tempSettings = 18;
myCar.adjustTemp();
console.log(myCar.temp);
