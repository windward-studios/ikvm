If you are using .NET 3.5 or earlier, then in the three .config files flip the order of the supportedRuntime nodes to:

        <supportedRuntime version="v2.0.50727" />
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5" />

When you build IKVM it will create these with V2 first as it must be in the above order to build IKVM (no idea why).

- windward