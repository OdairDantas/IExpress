// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Critical Code Smell", "S927:parameter names should match base declaration and other partial definitions", Justification = "<Pendente>", Scope = "member", Target = "~M:IExpress.Core.Messages.CommonMessages.Notifications.DomainNotificationHandler.Handle(IExpress.Core.Messages.CommonMessages.Notifications.DomainNotification,System.Threading.CancellationToken)~System.Threading.Tasks.Task")]
[assembly: SuppressMessage("Major Code Smell", "S3881:\"IDisposable\" should be implemented correctly", Justification = "<Pendente>", Scope = "type", Target = "~T:IExpress.Core.Data.Repository`1")]
[assembly: SuppressMessage("Blocker Code Smell", "S2953:Methods named \"Dispose\" should implement \"IDisposable.Dispose\"", Justification = "<Pendente>", Scope = "member", Target = "~M:IExpress.Core.Messages.CommonMessages.Notifications.DomainNotificationHandler.Dispose")]
