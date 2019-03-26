const { app, BrowserWindow } = require('electron')

function createWindow() {
  // Создаем окно браузера.
  let win = new BrowserWindow({
    width: 800,
    height: 700,
    frame: false,
    resizable: false,
    icon: __dirname + '/favicon.ico'
  })
  win.once('ready-to-show', () => {
    win.show()
  })

  // и загружаем index.html нашего приложения.
  win.loadFile('index.html')
}

app.on('ready', createWindow)

app.on('window-all-closed', () => {
  app.quit();
});