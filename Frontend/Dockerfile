# Build Stage
FROM node:22-alpine AS build
WORKDIR /app

COPY package*.json ./
RUN npm ci

COPY . .
RUN npm run build --configuration=production

# Serve Stage
FROM nginx:alpine
# Copy the built Angular app from the dist folder
COPY --from=build /app/dist/zoo-monkeys/browser /usr/share/nginx/html

# Copy custom nginx config if we had one for fallback routing
# For now, default alpine is ok, but we usually need a fallback for SPAs:
RUN echo 'server { listen 80; location / { root /usr/share/nginx/html; try_files $uri $uri/ /index.html; } }' > /etc/nginx/conf.d/default.conf

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
