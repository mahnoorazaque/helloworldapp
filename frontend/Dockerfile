# Use Node.js image for building Angular app
FROM node:20 AS build
WORKDIR /app

# Copy package files and install dependencies
COPY package.json package-lock.json ./
RUN npm install

# Copy project files and build
COPY . .
RUN npm run build --prod

# Use Nginx to serve Angular app
FROM nginx:alpine
COPY --from=build /app/dist/frontend /usr/share/nginx/html

# Expose Angular app port
EXPOSE 80

# Start Nginx
CMD ["nginx", "-g", "daemon off;"]
