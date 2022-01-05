


SHELL_DIR=$(dirname "$BASH_SOURCE")
APP_DIR=$(cd $SHELL_DIR; pwd)
cd $APP_DIR

cp -Rf ./build /opt/homebrew/var/www/

# nginx
# http://localhost:8080/build/