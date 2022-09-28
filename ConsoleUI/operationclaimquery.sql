select* from dbo.OperationClaims
select *from dbo.UserOperationClaims
select *from dbo.Users

select c.Id,c.Email,a.Name
from dbo.OperationClaims a join dbo.UserOperationClaims b
on a.Id=b.OperationClaimId join dbo.Users c on b.UserId=c.Id