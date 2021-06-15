
# variable configuration
globomanticsApiName=GlobomanticsTrafficInfoAPI$(openssl rand -hex 5)
RESOURCE_GROUP=$(az group list --query "[0].name" -o tsv)
PLAN_NAME=myPlan
DEPLOY_USER="randomUser1$(openssl rand -hex 5)"
DEPLOY_PASSWORD="Pw1$(openssl rand -hex 10)"
REMOTE_NAME=production

# Git configuration
GIT_USERNAME=randomgitName
GIT_EMAIL=random@test.com

git config --global user.name "$GIT_USERNAME"
git config --global user.email "$GIT_EMAIL"

# debugging
echo $RESOURCE_GROUP

# Azure Resource Creation

az appservice plan create --name $globomanticsApiName --resource-group $RESOURCE_GROUP --location centralus --sku FREE --verbose

az webapp create --name $globomanticsApiName --resource-group $RESOURCE_GROUP --plan $globomanticsApiName --deployment-local-git --verbose

az webapp deployment user set --user-name $DEPLOY_USER --password $DEPLOY_PASSWORD --verbose

GIT_URL="https://$DEPLOY_USER@$globomanticsApiName.scm.azurewebsites.net/$globomanticsApiName.git"

cd lab_azure_manage-apis-microsoft-azure-with-api-management

git remote add $REMOTE_NAME $GIT_URL

git status 

git checkout -b master

git status

git add .
git commit -m "temp"
git push "https://$DEPLOY_USER:$DEPLOY_PASSWORD@$globomanticsApiName.scm.azurewebsites.net/$globomanticsApiName.git" 

printf "Swagger URL: https://$globomanticsApiName.azurewebsites.net/swagger\n"

printf "Example URL: https://$globomanticsApiName.azurewebsites.net/swagger/v1/swagger.json\n\n"
