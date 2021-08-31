.PHONY: build build-ui buil-api


build-ui:
	docker build -f Dockerfile.ui -t taxes-ui .
build-api:
	docker build -f Dockerfile.api -t taxes-api .
build:
	make build-ui
	make build-api
up:
	docker-compose  up

clean:
	docker-compose down --rmi all

start:
	make build
	make up
test:
	cd .\SalesTaxesAPI.Tests\ && dotnet test
