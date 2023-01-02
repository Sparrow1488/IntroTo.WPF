using System.Reactive;
using System.Reactive.Linq;
using IntroTo.Reactive.Console;
using ReactiveUI;

#region Observable command

// var command = ReactiveCommand.CreateFromObservable<Unit, string>(_ =>
// {
//     Console.WriteLine("Task started");
//     Thread.Sleep(TimeSpan.FromSeconds(1));
//     Console.WriteLine("Task finished");
//     return Observable.Return("Hello World!");
// });
// command.Subscribe(Console.WriteLine);
//
// Console.WriteLine("Thread started...");
// command.Execute().Subscribe();
// Console.WriteLine("Thread finished");

#endregion

#region Synchronous command

// var command = ReactiveCommand.Create(() =>
//     Console.WriteLine("Reactive command"));
//
// command.Execute().Subscribe();

#endregion

#region Asynchronous command

// ObservableAsPropertyHelper<string[]> _names;
// ReactiveCommand<Unit, string[]> LoadNames;
// string[] Names => _names.Value;
//
// LoadNames = ReactiveCommand.CreateFromTask(LoadNamesAsync);
//
// _names = LoadNames.ToProperty(this, x => Names, RxApp.MainThreadScheduler);
//
// Task<string[]> LoadNamesAsync()
// {
//     Task.Delay(1000).Wait();
//     return Task.FromResult(new[] {
//         "Valentin",
//         "Yuri",
//         "Gosha"
//     });
// }
    
#endregion

#region Can execute command

var lesson = new CanExecuteCommandLesson();
Console.WriteLine(lesson.SaveCommand.CanExecute(null));
lesson.Username = "Test";
lesson.Password = "1234";
Console.WriteLine(lesson.SaveCommand.CanExecute(null));
if(lesson.SaveCommand.CanExecute(null)) lesson.SaveCommand.Execute(null);

#endregion