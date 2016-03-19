﻿using FlickrSearcher.Search;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;

namespace FlickrSearcher.Tests.ImageUrlFactoryTests
{
    public class CreateImageUrl
    {
        private FlickerPhoto photo;
        private ImageUrlFactory sut;

        public CreateImageUrl()
        {
            photo = (new Fixture()).Create<FlickerPhoto>();
            sut = new ImageUrlFactory();
        }

        [Theory]
        [InlineData(ImageSize.Large, "Large")]
        [InlineData(ImageSize.Small, "Small")]
        [InlineData(ImageSize.Icon, "Icon")]
        public void create_image_url_of_size(
            ImageSize size,
            string expectedUrlEnding)
        {
            // arrange
            var expected = string.Format(
                "http://localhost:62276/api/image/{0}/{1}/{2}_{3}/{4}",
                photo.Farm,
                photo.Server,
                photo.Id,
                photo.Secret,
                expectedUrlEnding);

            // act // assert
            sut.CreateImageUrl(photo, size)
                .Should()
                .Be(expected);
        }
    }
}