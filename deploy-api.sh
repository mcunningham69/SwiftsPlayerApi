#!/bin/bash

# === CONFIGURATION ===
APP_NAME="swiftsplayerapi2025"
RESOURCE_GROUP="SwiftsApiRG"
OUTPUT_DIR="publish"
ZIP_NAME="deploy.zip"

# === CLEAN OLD BUILD ===
echo "🔄 Cleaning old build..."
rm -rf $OUTPUT_DIR $ZIP_NAME

# === BUILD APP ===
echo "🛠  Publishing API..."
dotnet publish -c Release -o $OUTPUT_DIR

# === ZIP CONTENTS ===
echo "📦 Zipping output..."
cd $OUTPUT_DIR
zip -r ../$ZIP_NAME *
cd ..

# === DEPLOY TO AZURE ===
echo "☁️  Deploying to Azure Web App: $APP_NAME..."
az webapp deploy \
  --resource-group $RESOURCE_GROUP \
  --name $APP_NAME \
  --src-path $ZIP_NAME \
  --type zip

# === CLEANUP OPTIONAL ===
# Uncomment to remove files after deploy
# echo "🧹 Cleaning up..."
# rm -rf $OUTPUT_DIR $ZIP_NAME

echo "✅ Deployment complete!"

