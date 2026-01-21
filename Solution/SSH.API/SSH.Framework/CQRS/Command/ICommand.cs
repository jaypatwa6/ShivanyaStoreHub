using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSH.Framework.CQRS
{
    public interface ICommand : IMessage
    {
    }

    /// <summary>
    /// Command with input data
    /// </summary>
    /// <typeparam name="TInput">The type of the input.</typeparam>
    public interface ICommand<TInput> : ICommand
    {
        /// <summary>
        /// Gets or sets the input.
        /// </summary>
        /// <value>
        /// The input.
        /// </value>
        TInput CommandInput { get; set; }
    }

    /// <summary>
    /// Command with input data and its result
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <typeparam name="TInput">The type of the input.</typeparam>
    public interface ICommand<TResult, TInput> : ICommand<TInput>
    {
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        TResult ProcessResult { get; set; }
    }
}
