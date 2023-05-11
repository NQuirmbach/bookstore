using BookStore.UserService.Database.Entities;

namespace BookStore.UserService.Graph.Users;

public class UserObjectType : ObjectType<User>
{
    protected override void Configure(IObjectTypeDescriptor<User> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.ImplementsNode();

        descriptor.Field(m => m.Id).ID();
        
        descriptor.Field(m => m.Email);
        descriptor.Field(m => m.FirstName);
        descriptor.Field(m => m.LastName);
    }
}