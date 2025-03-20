# Use Node.js image to build and serve the frontend
FROM node:20
WORKDIR /app

# Copy package files and install dependencies
COPY ./frontend/package.json ./frontend/package-lock.json ./
RUN npm install

# Copy the rest of the frontend code
COPY ./frontend ./

# Build and serve the frontend
RUN npm run build
CMD ["npm", "run", "start"]
EXPOSE 4200
