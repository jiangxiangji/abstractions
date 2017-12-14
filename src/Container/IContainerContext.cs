﻿using System;
using Unity.Policy;
using Unity.Registration;

namespace Unity.Container
{
    /// <summary>
    /// An interface exposing internal UnutyContainer API to 
    /// implementation types. 
    /// </summary>
    /// <remarks>This interface is used to access loacl container's engine and services.</remarks>
    public interface IContainerContext 
    {
        /// <summary>
        /// Reference to current IUnityContainer
        /// </summary>
        IUnityContainer Container { get; }

        /// <summary>
        /// Retrieves registration for requested named type
        /// </summary>
        /// <param name="type">Registration type</param>
        /// <param name="name">Registration name</param>
        /// <param name="create">Instruncts container if it should create registration if not found</param>
        /// <returns>Registration for requested named type or null if named type is not registered and <see cref="create"/> is false</returns>
        IRegistration Registration(Type type, string name, bool create = false);

            /// <summary>
        /// Generic method to retrieve policy for registered named type.
        /// </summary>
        /// <typeparam name="TPolicy">Type of the policy to retrieve</typeparam>
        /// <param name="type">Registered type</param>
        /// <param name="name">Name of registered type</param>
        /// <returns>Returns <see cref="IBuilderPolicy"/> derived policy.</returns>
        TPolicy Policy<TPolicy>(Type type, string name) where TPolicy : IBuilderPolicy;

        /// <summary>
        /// Generic method to set policy for registered named type.
        /// </summary>
        /// <typeparam name="TPolicy">Type of the policy to set</typeparam>
        /// <param name="type">Registered type</param>
        /// <param name="name">Name of registered type</param>
        /// <param name="value">Policy to be set</param>
        void Policy<TPolicy>(Type type, string name, TPolicy value) where TPolicy : IBuilderPolicy;
    }
}
