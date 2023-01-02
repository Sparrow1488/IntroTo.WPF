using System.Reactive;
using System.Reactive.Linq;
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

var command = ReactiveCommand.Create(() =>
    Console.WriteLine("Reactive command"));

command.Execute().Subscribe();

#endregion