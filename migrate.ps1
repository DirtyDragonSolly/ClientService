# Create migrations for each context

Add-Migration InitialCreate -Context ClientContext

# Apply migrations for each context

Update-Database InitialCreate -Context ClientContext